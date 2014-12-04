import java.io.*;
import java.util.*;

public class MiscHexer{
	static ArrayList<String> keywords = new ArrayList<String>();

	public static void main(String[] args){		
		ArrayList<String> outputFilePaths = new ArrayList<String>();		
		readConfigFile("config.txt", outputFilePaths);
		
		if(outputFilePaths.size() < 1){
			System.out.println("Config file contained no paths!");
			return;
		}
		
		ArrayList<String> inputFilesPaths = new ArrayList<String>();
		getInputFiles("input",inputFilesPaths);

		getKeywords("keywords.txt", keywords);

		copyFiles(inputFilesPaths, outputFilePaths);
	}
	
	private static void copyFiles(ArrayList<String> inputFilesPaths, ArrayList<String> outputFilePaths){
		File folder = new File("output");
		File[] listOfFiles = folder.listFiles(); 
		new File("output/MiscHexer_Output_" + listOfFiles.length + "/models").mkdir();
		
		for(int i = 0; i < outputFilePaths.size(); i++){
			String outputFile = outputFilePaths.get(i);
			String prefix = "output/MiscHexer_Output_" + listOfFiles.length + "/models/";
					
			for(int j = 0; j < inputFilesPaths.size(); j++){
				String inputFile = inputFilesPaths.get(j);
				if(inputFile.contains(".DS_Store")){
					continue;
				}
				
				if(inputFile.contains(".mdl")){
					try{
						hexMdlFile(inputFile, outputFile, prefix);
					} catch(Exception e){
						System.out.println(e);
					}
				} else{
					try{
						copySingleFile(inputFile, prefix + outputFile);
					} catch(Exception e){
						System.out.println(e);
					}
				}	
			}			
		}				
	}
	
	private static int getIndexOfKeyword(char[] charStream){
		String stream = new String(charStream);
		for(int i = 0; i < keywords.size(); i++){
			if(stream.indexOf(keywords.get(i)) != -1){
				return stream.indexOf(keywords.get(i));
			}
		}
		
		return -1;
	}
	
	private static void hexMdlFile(String inputFile, String outputFile, String prefix) throws IOException{
		boolean isMac = System.getProperty("os.name").toLowerCase().contains("mac");

		FileInputStream input = null;
		FileOutputStream output = null;		
		outputFile += ".mdl";

		try{		
			File file = new File(prefix + outputFile);		
			System.out.println(prefix + outputFile);							
			if(!file.exists()) {
				file.getParentFile().mkdirs();
			}
			
 			input = new FileInputStream("input/" + inputFile);
 			
 			int c;
 			char[] charStream = new char[10000];
 			int cSIndex = 0;
 			
 			int i = 0;
 			int zeroIndex = -1;			
 			int indexOfKeyword = -1;
			while (((c = input.read()) != -1) && indexOfKeyword == -1) {
				charStream[cSIndex++] = Character.toChars(c)[0];
				indexOfKeyword = getIndexOfKeyword(charStream);
				i++;
			}
			
			//System.out.println("Index: " + indexOfKeyword);
			
			while (((c = input.read()) != -1) && zeroIndex == -1) {
				if(c == 0){
					zeroIndex = i;
				}
				i++;
			}
			
			input.close();
			 	
 			input = new FileInputStream("input/" + inputFile);
            output = new FileOutputStream(prefix + outputFile);                       
			
			int matchIndex = 0;
			i = 0;
			int j = 0;
			
            while (((c = input.read()) != -1)) {
            	if(i < indexOfKeyword){
            	    output.write(c);
            	} else if(j < outputFile.length()){
            		char newChar = outputFile.charAt(j++);
            			
					if(isMac && newChar == '/'){
						newChar = '\\';
					} 
					//System.out.println(newChar);
					output.write(newChar);
            	} else if(i == outputFile.length() && i < zeroIndex){
            		output.write(0);
            	} else{
            		output.write(c);
            	}
            	i++;
            }			
		}catch(Exception e){
			System.out.println(e);
		}finally{
			if(input != null){
				input.close();
			} 
			if(output != null){
				output.close();
			}
		}
	}
	
	private static void copySingleFile(String inputFile, String outputFile) throws IOException{
		FileInputStream input = null;
		FileOutputStream output = null;		
		String extension = inputFile.substring(inputFile.indexOf("."), inputFile.length());
		outputFile += extension;

		try{		
			File file = new File(outputFile);		
			System.out.println(outputFile);							
			if(!file.exists()) {
				file.getParentFile().mkdirs();
			}
			
 			input = new FileInputStream("input/" + inputFile);
 						
            output = new FileOutputStream(outputFile);
            
            int c;
            while ((c = input.read()) != -1) {
                output.write(c);
            }			
		}catch(Exception e){
			System.out.println(e);
		}finally{
			if(input != null){
				input.close();
			} 
			if(output != null){
				output.close();
			}
		}
	}
	
	private static void getKeywords(String keywordFile, ArrayList<String> keywords){
		Scanner keywordScanner = null;
		
		try{
			keywordScanner = new Scanner(new File(keywordFile));		
		} catch (Exception e){
			System.out.println(e);
		}
				
		while(keywordScanner.hasNextLine()){
			keywords.add(keywordScanner.nextLine());							
		}
	}
	
	private static void getInputFiles(String inputFolderName, ArrayList<String> filePaths){ 
	    File[] listOfFiles = null;

	    try{
			File folder = new File(inputFolderName);
			listOfFiles = folder.listFiles(); 
			
			for(int i = 0; i < listOfFiles.length; i++){
				if(listOfFiles[i].isFile()){
					filePaths.add(listOfFiles[i].getName());
				}
			}
		}catch(Exception e){
			System.out.println(e);
		}
	}

	private static void readConfigFile(String cfgFileName, ArrayList<String> filePaths){		
		Scanner cfg = null;
		
		try{
			cfg = new Scanner(new File(cfgFileName));		
		} catch (Exception e){
			System.out.println(e);
		}
		
		String cfgLine;
		
		while(cfg.hasNextLine()){
			cfgLine = cfg.nextLine();
			
			int pos1 = cfgLine.indexOf("\"");
			int pos2 = cfgLine.lastIndexOf("\"");
			
			if(pos1 != pos2){
				filePaths.add(cfgLine.substring(pos1 + 1, pos2));				
			}
		}
	}
}